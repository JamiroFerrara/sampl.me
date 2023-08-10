<script lang="ts">
	let count = 0;
</script>

<p
	class="block card card-hover p-4 w-full cursor-pointer"
	on:click={() => {
		count = count + 1;
	}}
>
	<slot />
	{count}
</p>
